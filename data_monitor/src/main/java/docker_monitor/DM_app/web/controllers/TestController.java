package docker_monitor.DM_app.web.controllers;


import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.security.oauth2.provider.OAuth2Authentication;
import org.springframework.validation.annotation.Validated;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/")
@Validated
public class TestController {

    @GetMapping(value = "private")
    @PreAuthorize("hasAuthority('USER')")
    String privateAccess() {
        return "private test success";
    }
    @GetMapping(value = "private/admin")
    @PreAuthorize("hasAuthority('ADMIN')")
    String privateAccessAdmin() {
        return "private admin test success";
    }
    @GetMapping(value = "public")
    String publicAccess() {
        return "public test success";
    }

}
