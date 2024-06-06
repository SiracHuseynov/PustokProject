using PustokAB204.Business.Services.Abstracts;
using PustokAB204.Core.Models;
using PustokAB204.Core.RepositoryAbstracts;

namespace PustokAB204.Business.Services.Concretes;

public class FeatureService : IFeatureService
{
    private readonly IFeatureRepository _featureRepository;

    public FeatureService(IFeatureRepository featureRepository)
    {
        _featureRepository = featureRepository;
    }

    public async Task AddFeatureAsync(Feature feature)
    {
        await _featureRepository.AddAsync(feature);
        await _featureRepository.CommitAsync();
    }

    public void DeleteFeature(int id)
    {
        var existFeature = _featureRepository.Get(x => x.Id == id);
        if (existFeature == null) throw new NullReferenceException("Feature tapilmadi!");

        _featureRepository.Delete(existFeature);
        _featureRepository.Commit();
    }

    public List<Feature> GetAllFeatures(Func<Feature, bool>? func = null)
    {
        return _featureRepository.GetAll(func);
    }

    public Feature GetFeature(Func<Feature, bool>? func = null)
    {
        return _featureRepository.Get(func);
    }

    public void UpdateFeature(int id, Feature newFeature)
    {
        var oldFeature = _featureRepository.Get(x => x.Id == id);

        if (oldFeature == null) throw new NullReferenceException("feature tapilmadi!");

        oldFeature.Icon = newFeature.Icon;
        oldFeature.Title = newFeature.Title;
        oldFeature.Description = newFeature.Description;
        _featureRepository.Commit();
    }
}
