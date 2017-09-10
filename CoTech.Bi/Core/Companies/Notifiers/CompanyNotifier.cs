using System;
using System.Linq;
using System.Threading.Tasks;
using CoTech.Bi.Core.Companies.Models;
using CoTech.Bi.Core.Notifications.Models;
using CoTech.Bi.Core.Notifications.Repositories;
using CoTech.Bi.Core.Permissions.Model;
using CoTech.Bi.Core.Permissions.Repositories;
using CoTech.Bi.Core.Users.Models;
using CoTech.Bi.Core.Users.Repositories;

namespace CoTech.Bi.Core.Companies.Notifiers
{
    public class CompanyNotifier {
        private readonly NotificationRepository notificationRepository;
        private readonly UserRepository userRepository;
        private PermissionRepository permissionRepository;
        public CompanyNotifier(NotificationRepository notificationRepository,
                              UserRepository userRepository, 
                              PermissionRepository permissionRepository){

            this.notificationRepository = notificationRepository;
            this.userRepository = userRepository;
            this.permissionRepository = permissionRepository;
        }

        public async Task Created(CompanyEntity company, long creator) {
            var rootUsers = (await userRepository.GetRootUsers())
                .Where(u => u.Id != creator)
                .ToList();
            var receivers = rootUsers.Select(u => new ReceiverEntity {
              UserId = u.Id
            }).ToList();
            var notification = new NotificationEntity {
                SenderId = creator,
                Type = "CompanyCreated",
                Body = new CompanyCreated { 
                  CompanyId = company.Id
                },
                Receivers = receivers
            };
            await notificationRepository.Create(notification);
        }
    }
}