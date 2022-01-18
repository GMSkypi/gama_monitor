package docker_monitor.DM_app.constants;

public enum Group {
    CPU("Cpu"),
    IO("IO"),
    MEMORY("Memory"),
    NET("Net");

    private final String val;

    Group(String val) {
        this.val = val;
    }
    @Override
    public String toString() {
        return val;
    }
}

