using System.Collections.Generic;
using System.Web.Http;
using Umbraco.Core.Models;
using Umbraco.Web.WebApi;
using System.Linq;
using Umbraco.Core.Persistence.DatabaseModelDefinitions;
using NJFKModels;

namespace NJFK.Shop.Controllers
{
    [Route("api/[controller]")]
    public class CustomMemberApiController : UmbracoApiController
    {
        [HttpGet]

        public IEnumerable<MemberPickerModel> GetMembers([FromUri]string memberGroup)
        {
            var mem = new List<MemberPickerModel>();
            var memberService = Services.MemberService;
            if (!string.IsNullOrEmpty(memberGroup))
            {
                var groups = memberGroup.Split(',');
                foreach(var group in groups)
                {
                    var all = memberService.GetMembersByGroup(group);
                    mem.AddRange(ToModel(all));
                }
                
            }
            else
            {
                int totalRecords = 0;
                var all = memberService.GetAll(0, 1000, out totalRecords, "name", Direction.Ascending);
                mem = ToModel(all);
            }

            return mem.AsEnumerable();


        }
        private List<MemberPickerModel> ToModel(IEnumerable<IMember> members)
        {
            var mem = new List<MemberPickerModel>();
            foreach (var member in members)
            {
                mem.Add(new MemberPickerModel
                {
                    Id = member.Id,
                    Name = member.Name
                }
                );
            }
            return mem;
        }
    }
}
