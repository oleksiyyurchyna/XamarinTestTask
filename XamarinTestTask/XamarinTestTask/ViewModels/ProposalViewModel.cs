using System;
using System.Collections.ObjectModel;
using System.Linq;
using XamarinTestTask.Enums;
using XamarinTestTask.Models;

namespace XamarinTestTask.ViewModels
{
    public class ProposalViewModel : BaseViewModel
    {
        private Proposal _model;

        public ProposalViewModel(Proposal model)
        {
            _model = model;

            JobDates = new ObservableCollection<DateProposalsViewModel>(_model.JobDates.Select(x => new DateProposalsViewModel(x)));
        }

        public ProposalStatus Status => _model.Status;

        public string ProposalType => _model.ProposalType;
        public string JobTitle => _model.JobTitle;
        public string RateInfo { get { return $"{_model.Rate.ToString()} $/hours"; } }
        public string JobAddress => _model.JobTitle;
        public string WorkerTitle => _model.JobTitle;
        public int Rating => _model.Rating;
        public int RatingCount => _model.RatingCount;
        public string RatingInfo { get { return $"({RatingCount})"; } }
        public int NoShowsCount => _model.NoShowsCount;
        public int Age => _model.Age;
        public int YearsOfExperience => _model.YearsOfExperience;

        public ObservableCollection<DateProposalsViewModel> JobDates { get; set; }
    }
}
