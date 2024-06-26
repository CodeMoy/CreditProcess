namespace CreditProcess.Domain;
public abstract class BaseEntity
{
    public virtual Guid Id { get; protected set; }
    public virtual DateTime? CreatedDate { get; set; }
    public virtual DateTime? ModifiedDate { get; set; }
    public virtual Guid CreatedBy { get;  set; }
    public virtual Guid ModifiedBy { get;  set; }
}
