using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class Character : ScriptableObject {

    public new string name;
    public Sprite sprite;
    public int moveSpeed;
    public int jumpHeight;
    public int strength;
    public Ability[] abilities = new Ability[4];
}
