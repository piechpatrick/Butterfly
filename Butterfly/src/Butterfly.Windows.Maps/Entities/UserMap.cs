using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Butterfly.Models.Cores;
using Butterfly.MultiPlatform.ViewModels.Identities;
using Butterfly.Services.Database.Users;

namespace Butterfly.Maps.Entities
{
    public class UserMap : IUserMap
    {
        private readonly IUserService userService;
        public UserMap(IUserService userService)
        {
            this.userService = userService;
        }
        public UserViewModel Create(UserViewModel viewModel)
        {
            User user = ViewModelToModel(viewModel);

            return ModelToViewModel(userService.Create(user));
        }

        public UserViewModel Delete(UserViewModel viewModel)
        {
           return ModelToViewModel(this.userService.Delete(ViewModelToModel(viewModel)));
        }

        public IEnumerable<UserViewModel> GetAll()
        {
            return ModelToViewModel(this.userService.GetAll());
        }

        public UserViewModel Update(UserViewModel viewModel)
        {
            User user = ViewModelToModel(viewModel);

            return ModelToViewModel(userService.Update(user));
        }

        public UserViewModel ModelToViewModel(User model)
        {
            return new UserViewModel();
        }

        public IEnumerable<UserViewModel> ModelToViewModel(IEnumerable<User> models)
        {
            return new List<UserViewModel>();
        }

        public User ViewModelToModel(UserViewModel viewModel)
        {
            return new User() { Name = viewModel.Name, Password = viewModel.Password };
        }
    }
}
