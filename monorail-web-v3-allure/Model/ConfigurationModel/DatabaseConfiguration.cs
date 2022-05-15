namespace monorail_web_v3.Model.ConfigurationModel
{
    public class DatabaseConfiguration
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public string DataSource { get; set; }
        public string InitialCatalogPrefix { get; set; }
    }
}