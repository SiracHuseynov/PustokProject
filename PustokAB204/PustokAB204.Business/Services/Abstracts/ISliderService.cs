using PustokAB204.Core.Models;

namespace PustokAB204.Business.Services.Abstracts;

public interface ISliderService
{
    Task AddSliderAsync(Slider slider);
    void DeleteSlider(int id);
    void UpdateSlider(int id, Slider newSlider);

    Slider GetSlider(Func<Slider, bool>? func = null);
    List<Slider> GetAllSliders(Func<Slider, bool>? func = null);
}
