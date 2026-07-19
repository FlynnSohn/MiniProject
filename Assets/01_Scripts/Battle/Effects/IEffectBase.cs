
public enum TargetScope
{
    Self = 0,
    Target = 1
}
public interface IEffectBase
{
    IEffectAction Set(Character source, Character target);
    // source 누가 이 작업을 실행할 것인지
    // target 이 적용을 받는 대상이 누군지

}
