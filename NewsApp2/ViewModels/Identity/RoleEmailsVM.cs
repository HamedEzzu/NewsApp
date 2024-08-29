using NewsApp2.Classes;

namespace NewsApp2.ViewModels.Identity
{
    public class RoleEmailsVM : RolesVM
    {
        public MailSettings MailSettings { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public IFormFileCollection? Attachments { get; set; }
    }

}

