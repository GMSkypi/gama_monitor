namespace data_viewer.Model.Notification
{
    public class ChangeNotify
    {
        public Trigger trigger { get; set; }
        public long comparedToBefore { get; set; }
    }
}