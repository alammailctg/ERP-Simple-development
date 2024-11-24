using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.HumanResources
{
    public class TrainingSession
    {
        public int Id { get; set; }                                // Unique identifier for each training session
        public string? Title { get; set; }                          // Title of the training session
        public DateTime ScheduledDate { get; set; }                // Date the training session is scheduled
        public bool Completed { get; set; }                         // Indicates if the training session has been completed
        public string? comments { get; set; }                           // Any additional notes regarding the training session
    }
}
