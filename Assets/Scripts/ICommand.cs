
/*Command pattern implementation*/
public interface ICommand
{
    /*Execute method
     <param name="_player"> player instance </param>*/
    public void Execute(ref Player _player);
}
