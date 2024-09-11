using System;

namespace app3
{
    public interface IIncidentFactory
    {
        Incident CreateIncident(string incidentID, string incidentDate, string reportedDate, string comments, Staff reportingStaff);
        DenialOfService CreateDenialOfService(string incidentID, string incidentDate, string reportedDate, string comments,
                                               Staff reportingStaff, string serverID, string service, string outcome, bool isActive);
    }
}
