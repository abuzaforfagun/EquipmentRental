namespace EquipmentRental.Repository
{
    public interface IUnitOfWork
    {
        IEquipementRepository EquipementRepository { get; set; }
    }
}