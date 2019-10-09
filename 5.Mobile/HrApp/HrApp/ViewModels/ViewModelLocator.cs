using CommonServiceLocator;

namespace HrApp.ViewModels
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            AppSetup.Initialize();
        }

        public LoginViewModel LoginVM 
        { 
            get
            {
                return ServiceLocator.Current.GetInstance<LoginViewModel>(); 
            } 
        }

        public CandidateViewModel CandidateVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CandidateViewModel>();
            }
        }
    }
}
