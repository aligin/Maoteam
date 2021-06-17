using System.Collections.Generic;

namespace MaoTeam.Models.LocalUsers
{
    public class Telephone
    {
        readonly List<string> _telephones = new List<string>();
        
        public IEnumerable<string> Telephones
        {
            get { return _telephones.AsReadOnly(); }
        }

        public string MainTelephone { get; set; }

        public void AddTelephone(string telephone)
        {
            if (_telephones.Contains(telephone))
                return;
            _telephones.Add(telephone);
        }

        public void RemoveTelephone(string telephone)
        {
            _telephones.Remove(telephone);
        }
    }
}
