using System;
using System.Collections.Generic;
using System.Text;

namespace Butterfly.Interfaces.Maps.Entities
{
    public interface IEntityMap<TModel,TViewModel> 
    {
        TViewModel Create(TViewModel viewModel);

        TViewModel Update(TViewModel viewModel);

        TViewModel Delete(TViewModel viewModel);

        IEnumerable<TViewModel> GetAll();

        TViewModel ModelToViewModel(TModel model);

        IEnumerable<TViewModel> ModelToViewModel(IEnumerable<TModel> models);

        TModel ViewModelToModel(TViewModel viewModel);

    }
}
