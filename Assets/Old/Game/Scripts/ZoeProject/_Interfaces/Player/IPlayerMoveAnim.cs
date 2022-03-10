
namespace ZoeProject
{
    public interface IPlayerMoveAnim 
    {
        //初始化
        public void Initial(PlayerMoveSettings playerMoveSettings);

        //是否啟用
        public void IsEnable(bool isEnable);

        //執行
        public void PlayMoveAnim(bool isGround);
    } 
}