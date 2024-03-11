using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTOs
{
   public record TransactionDTO(decimal value, long senderId, long receiverId){}
}