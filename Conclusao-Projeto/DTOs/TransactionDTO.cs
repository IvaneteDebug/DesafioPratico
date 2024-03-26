namespace Conclusao_Projeto.DTOs
{
    public class TransactionDTO
    {
        public decimal Value { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }

        public TransactionDTO() { }

        public TransactionDTO(decimal value,int senderId, int receiverId)
        {
            Value = value;
            ReceiverId = receiverId;
            SenderId = senderId;
        }
    }
}
