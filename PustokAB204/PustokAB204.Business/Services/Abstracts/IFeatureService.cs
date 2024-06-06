using PustokAB204.Core.Models;

namespace PustokAB204.Business.Services.Abstracts;

public interface IFeatureService
{
    Task AddFeatureAsync(Feature feature);
    void DeleteFeature(int id);
    void UpdateFeature(int id, Feature newFeature);

    Feature GetFeature(Func<Feature, bool>? func = null);
    List<Feature> GetAllFeatures(Func<Feature, bool>? func = null);
}
