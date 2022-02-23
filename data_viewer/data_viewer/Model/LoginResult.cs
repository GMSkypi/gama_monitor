namespace data_viewer.Model
{
    public class LoginResult
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string scope { get; set; }
        public bool Successful { get; set; }
        public string error_description { get; set; }
    }
}