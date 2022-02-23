package docker_monitor.DM_app.web.controllers;

import docker_monitor.DM_app.process.service.imp.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.validation.annotation.Validated;
import org.springframework.web.bind.annotation.*;

@CrossOrigin
@RestController
@RequestMapping("/user")
@Validated
public class UserController {

    @Autowired
    UserService userService;

    @PostMapping(value = "/username", params = {"username"})
    @ResponseStatus(HttpStatus.OK)
    public boolean changeUsername(@RequestParam("username") String newUsername){
        return userService.updateUserUsername(newUsername);
    }
    @PostMapping(value = "/password", params = {"password"})
    @ResponseStatus(HttpStatus.OK)
    public boolean changePassword(@RequestParam("password") String newPassword){
        return userService.updateUserPassword(newPassword);
    }
}
