using System.Collections.Generic;

namespace SimpleMvc.App.BindingModels
{
    public class UserProfileViewModel
    {
        public string Username { get; set; }

        public int UserId { get; set; }

        public IEnumerable<NoteViewModel> Notes { get; set; }
    }
}