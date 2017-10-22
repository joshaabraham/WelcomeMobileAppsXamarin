using MobileApps.DAL.Repository;
using MobileApps.Models.Contracts.Repository;
using MobileApps.Models.Models;
using MobileApps.ViewModels.Kiosk.SubViewModels;
using MobileApps.ViewModels.SubViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApps.ViewModels
{
    class LeadViewModel
    {
        public LeadViewModel()
        {
            Lead = new Lead();
            VMLang = new LanguagePromptViewModel();
        }

        private Lead _lead;
        private ILeadRepository _repository = new LeadRepository();
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private LanguagePromptViewModel _VMLang;
        private LeadAttributesViewModel _VMLeadAttributes;

        public LanguagePromptViewModel VMLang
        {
            get { return _VMLang; }
            set { _VMLang = value; }
        }
        public LeadAttributesViewModel VMLeadAttributes
        {
            get { return _VMLeadAttributes; }
            set { _VMLeadAttributes = value; }
        }


        public Lead Lead
        {
            get { return _lead; }
            set
            {
                if (value != _lead)
                {
                    _lead = value;
                }
            }
        }

        private void submitLead()
        {
            // ADD TO LOCAL DB ON DEVICE 
            _repository.AddLeadAsync(_lead);

            // DISPLAY MESSAGE - ACKNOWLEDGMENT
            // MessageUser = "Thank you, please be seated in the waiting area";
        }
    }
}
