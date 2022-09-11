using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.FeatureManagement;

namespace FeatureManagement.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IFeatureManager _featureManager;
        public bool SecretFeatureEnabled { get; set; }
        public IndexModel(ILogger<IndexModel> logger, IFeatureManager featureManager)
        {
            _logger = logger;
            _featureManager = featureManager;
        }

        public async void OnGet()
        {
            SecretFeatureEnabled = await _featureManager.IsEnabledAsync(Constants.SecreteFeature);
            _logger.LogInformation($"Secret Feature value: {SecretFeatureEnabled}");
        }
    }

    public static class Constants
    {
        public static readonly string SecreteFeature = nameof(SecreteFeature);
    }
}
