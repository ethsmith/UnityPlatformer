namespace entity
{
    public abstract class Pawn
    {
        public float Health { get; set; }
        
        public float Damage { get; set; }
        
        public float Speed { get; set; }
        
        public abstract void Move();
    }
}