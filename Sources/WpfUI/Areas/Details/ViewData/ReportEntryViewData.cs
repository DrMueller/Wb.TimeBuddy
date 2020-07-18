using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Configuration.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Rules;
using Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Validation.Models;
using Mmu.Wb.TimeBuddy.Domain.Areas.Models.Management;

namespace Mmu.Wb.TimeBuddy.WpfUI.Areas.Details.ViewData
{
    public class ReportEntryViewData : ValidatableViewModel<ReportEntryViewData>
    {
        private string _beginTime;
        private string _endTime;
        private string _workDescription;

        public string BeginTime
        {
            get => _beginTime;
            set
            {
                if (_beginTime != value)
                {
                    _beginTime = value;
                    OnPropertyChanged();
                }
            }
        }

        public string EndTime
        {
            get => _endTime;
            set
            {
                if (_endTime != value)
                {
                    _endTime = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ReportEntryId { get; set; }

        public string WorkDescription
        {
            get => _workDescription;
            set
            {
                if (_workDescription != value)
                {
                    _workDescription = value;
                    OnPropertyChanged();
                }
            }
        }

        protected override ValidationContainer<ReportEntryViewData> ConfigureValidation(IValidationConfigurationBuilder<ReportEntryViewData> builder)
        {
            return builder
                .ForProperty(f => f.BeginTime)
                .ApplyRule(ValidationRuleFactory.StringNotNullOrEmpty())
                .ApplyRule(BeginTimeBeforeEndTime)
                .BuildForProperty()
                .ForProperty(f => f.EndTime)
                .ApplyRule(BeginTimeBeforeEndTime)
                .BuildForProperty()
                .ForProperty(f => f.WorkDescription)
                .BuildForProperty()
                .Build();
        }

        private ValidationResult BeginTimeBeforeEndTime(object value)
        {
            var endTime = TimeStamp.TryParsing(EndTime).Reduce(() => null);
            var beginTime = TimeStamp.TryParsing(BeginTime).Reduce(() => null);

            if (beginTime == null || endTime == null)
            {
                return ValidationResult.CreateValid();
            }

            if (beginTime.ToTimeSpan() >= endTime.ToTimeSpan())
            {
                return ValidationResult.CreateInvalid("End time must be after begin time.");
            }
            else
            {
                return ValidationResult.CreateValid();
            }
        }
    }
}