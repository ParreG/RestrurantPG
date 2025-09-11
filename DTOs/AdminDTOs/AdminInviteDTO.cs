using RestrurantPG.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestrurantPG.DTOs.AdminDTOs
{
    public class AdminInviteDTO
    {
        public int Invite_Id { get; set; }
        public bool IsUsed { get; set; } = false;
    }
}
