namespace AenEnterprise.FrontEndMvc.Models.Authentications
{
    public class AssignRoleRequestForm
    {
        public int UserId { get; set; }
        public List<int> RoleIds { get; set; }
    }
}
