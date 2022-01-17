package docker_monitor.DM_app.process.object;

import java.util.List;

public class MetricPair<C, T> {
    C container;
    List<T> metrics;

    public MetricPair(C container, List<T> metrics){
        this.container = container;
        this.metrics = metrics;
    }

    public C getContainer() {
        return container;
    }

    public List<T> getMetrics() {
        return metrics;
    }
}
