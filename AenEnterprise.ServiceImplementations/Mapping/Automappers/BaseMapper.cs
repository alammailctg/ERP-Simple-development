using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Mapping.Automappers
{
    public static class BaseMapper
    {
        public static TView ConvertToView<TModel, TView>(this TModel model, IMapper mapper)
        {
            return mapper.Map<TModel, TView>(model);
        }

        public static IEnumerable<TView> ConvertToViews<TModel, TView>(this IEnumerable<TModel> models, IMapper mapper)
        {
            return mapper.Map<IEnumerable<TModel>, IEnumerable<TView>>(models);
        }
    }

}
