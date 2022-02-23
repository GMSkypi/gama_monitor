namespace data_viewer.Model
{
    public class LoginCredential
    {
        public string grant_type { get; set; }
         public string username { get; set; }
         
         public string password { get; set; }
            
         
         public LoginCredential(string uname, string password, string grant_type)
         {
             this.grant_type = grant_type;
             this.username = uname;
             this.password = password;
         }
    }
}