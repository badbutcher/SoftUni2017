namespace TeamBuilder.App.Utilities
{
    using System.Linq;
    using Data;
    using Models;

    class CommandHelper
    {
        public static bool IsTeamExisting(string teamName)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                return context.Teams.Any(t => t.Name == teamName);
            }
        }

        public static bool IsUserExisting(string username)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                return context.Users.Any(t => t.Username == username);
            }
        }

        public static bool IsInviteExisting(string teamName, User user)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                return context.Invitation
                    .Any(i => i.Team.Name == teamName && i.InvitedUserId == user.Id && i.IsActive);
            }
        }

        public static bool IsMemberOfTeam(string teamName, string username)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                return context.Teams.Any(t => t.Name == teamName && t.Members.Any(m => m.Username == username));
            }
        }

        public static bool IsEventExisting(string eventName)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                return context.Event.Any(e => e.Name == eventName);
            }
        }

        public static bool IsUserCreatorOfEvent(string eventName, int id)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                User user = context.Users.FirstOrDefault(u => u.Id == id);
                Event ev = context.Event.FirstOrDefault(e => e.Name == eventName);

                return ev.CreatorId == user.Id;
            }
        }

        public static bool IsUserCreatorOfTeam(string teamName, string userName)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                User user = context.Users.FirstOrDefault(u => u.Username == userName);
                Team team = context.Teams.FirstOrDefault(t => t.Name == teamName);

                return team.CreatorId == user.Id;
            }
        }
    }
}