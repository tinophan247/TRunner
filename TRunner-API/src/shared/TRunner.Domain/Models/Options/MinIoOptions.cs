namespace TRunner.Domain.Models.Options
{
    public class MinIoOptions
    {
        public static string JsonKey => nameof(MinIoOptions);

        public string Bucket { get; set; }

        public string Server { get; set; }

        public string AccessKey { get; set; }

        public string SerectKey { get; set; }

        public string MinIoApiDomain { get; set; }
    }
}
