using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Xamarin.Permissions
{
    public static class CrossPermissionChecker
    {
        public static async Task<bool> CheckAllPermissions()
        {
            var statuses = new Dictionary<Permission,PermissionStatus>()
            {

                {Permission.Camera, await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera) },
                {Permission.Microphone, await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Microphone) },
                {Permission.Location, await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location) },
                {Permission.Storage, await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage) },
                {Permission.LocationAlways, await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.LocationAlways) },
                {Permission.LocationWhenInUse, await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.LocationWhenInUse)}
            };

            if(statuses.Any(s => s.Value != PermissionStatus.Granted))
                await CrossPermissions.Current.RequestPermissionsAsync( statuses.Select(s => s.Key).ToArray());
            return await Task.FromResult(true);
        }
    }
}
