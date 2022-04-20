package docker_monitor.DM_app.process.service.imp;

import docker_monitor.DM_app.process.service.ConfigurationLoader;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.core.authority.SimpleGrantedAuthority;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.stereotype.Service;

import java.util.Arrays;
import java.util.HashMap;
import java.util.Objects;

import static java.lang.Boolean.parseBoolean;
import static java.lang.String.valueOf;

@Service
public class UserService implements UserDetailsService {

    @Autowired
    ConfigurationLoader configurationLoader;

    @Override
    public UserDetails loadUserByUsername(String username) throws UsernameNotFoundException {
        HashMap<String,String> values =
                configurationLoader.loadProps(Arrays.asList("web.username","web.password"));
        if(username.equals(values.get("web.username"))){
            GrantedAuthority authority = new SimpleGrantedAuthority("USER");
            return new org.springframework.security.core.userdetails.User(values.get("web.username"),
                    values.get("web.password"), // password ahoj
                    Arrays.asList(authority));
        }
        else{
            throw new UsernameNotFoundException(username + " is not equal to:" +values.get("web.username") );
        }
    }
    public boolean updateUserUsername(String newUsername){
        HashMap<String,String> values = new HashMap<>() {{
            put("web.username", newUsername);
        }};
        return configurationLoader.saveProps(values,"host settings");
    }
    public boolean updateUserPassword(String password){
        HashMap<String,String> values = new HashMap<>() {{
            put("web.password", password);
        }};
        return configurationLoader.saveProps(values,"host settings");
    }

}