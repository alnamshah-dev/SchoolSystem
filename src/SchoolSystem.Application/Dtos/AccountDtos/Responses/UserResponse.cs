using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Application.Dtos.AccountDtos.Responses;

public record UserResponse(string Id,string UserName,string Email,IEnumerable<string> Roles);

