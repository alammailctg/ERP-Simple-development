using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.HumanResources
{
    public class Onboarding
    {
        public int Id { get; set; }                       
        public int EmployeeId { get; set; }               
        public DateTime OnboardingStartDate { get; set; } 
        public DateTime? OnboardingEndDate { get; set; }  
        public bool DocumentsSubmitted { get; set; }      
        public bool TrainingCompleted { get; set; }       
        public string Status { get; set; }                
        public List<TrainingSession>? TrainingSessions { get; set; }
        public string Feedback { get; set; }                       // Feedback or notes regarding the onboarding experience
        public DateTime CreatedAt { get; set; }                    // Timestamp for when the onboarding record was created
        public DateTime UpdatedAt { get; set; }                    // Timestamp for the last update to the onboarding record

        public Employee Employee { get; set; }                     // Navigation property linking to the Employee entity
    }
}
