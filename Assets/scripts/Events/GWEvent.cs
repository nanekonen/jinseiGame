using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GWEvent : ForcedEvent 
{


    public GWEvent(): base(){}

    public override IEnumerator execute(Season season, Round round, Player player)
    {
         Debug.Log("this is from spring force event");

        if (season.getID() != Season.SPRING) yield break;
        if (round.getRound() != 2) yield break;

        ProgressUI.progressUI.changeTurn(player);

        ProgressUI.progressUI.setInstructionSpace( player.pi.name + "さんの強制イベントです！！");
        yield return KeyManager.keyManager.waitForSpace();

        ProgressUI.progressUI.setInstructionSpace
        (
            "ゴールデンウィーク到来！遊園地に遊びに行きます。思い切り楽しんで、素敵な時間を過ごしましょう！ 心から楽しい時間を過ごすために、どちらの" 
            + ( (player.pi.gender == Gender.MAN)? "女" : "男" )  
            + "性と過ごすか選択してください。 "
        );

        yield return KeyManager.keyManager.waitForSpace();

        List<string> friendNames = player.pi.lovers.getAllLoverName();
        string friendName = "";


        ProgressUI.progressUI.setInstructionSpace
        (
           friendNames[0] + ":右矢印 " + friendNames[1] + ":左矢印"
        );
        
        IEnumerator waitForRightOrLeftArrow = KeyManager.keyManager.waitForRightOrLeftArrow();
        yield return waitForRightOrLeftArrow;
        string leftOrRight = (string)waitForRightOrLeftArrow.Current;

        if (leftOrRight == "right")
        {
            friendName = friendNames[0];
        }
        else
        {
            friendName = friendNames[1];
        }

        if( player.pi.gender == Gender.WOMAN )
        {
            ProgressUI.progressUI.setInstructionSpace
            (
                friendName + 
                ":「今日は楽しかったね。遊園地めっちゃ盛り上がった！」 "
            );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setInstructionSpace
            (
                friendName + 
                ":「今日は楽しかったね。遊園地めっちゃ盛り上がった！」\r\n" + "" +
                "あなた:「うん、最高だった。ジェットコースターも観覧車もすごかったね。」 "
            );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setInstructionSpace
            (
                friendName + 
                ":「今日は楽しかったね。遊園地めっちゃ盛り上がった！」 \r\n" + "" +
                "あなた「うん、最高だった。ジェットコースターも観覧車もすごかったね。」 \r\n" + 
                friendName + 
                ":「君と一緒にいると、どんな場所も楽しいな。」"
            );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setInstructionSpace
            (
                "A．「そうだね、私もすごく楽しかった。ありがとう。」 \r\n" + "" +
                "B．「また行きたくなっちゃったね！一緒に行ける日を楽しみにしてるね」"
            );

            IEnumerator waitForAOrB = KeyManager.keyManager.waitForAOrB();
            yield return waitForAOrB;
            string AorB = (string)waitForAOrB.Current;
        }
        else if( player.pi.gender == Gender.MAN )
        {
            ProgressUI.progressUI.setInstructionSpace
            (
                "あなた:「今日は楽しかったね。遊園地めっちゃ盛り上がった！」"
            );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setInstructionSpace
            (
                friendName + 
                ":「うん、最高だった。ジェットコースターも観覧車もすごかったね。」"
            );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setInstructionSpace
            (
                "A．「君と一緒にいると、どんな場所も楽しいな。」 \r\n" + "" +
                "B．「また行こうぜ！次はもっと楽しい時間を過ごそう！」"
            );

            IEnumerator waitForAOrB = KeyManager.keyManager.waitForAOrB();
            yield return waitForAOrB;
            string AorB = (string)waitForAOrB.Current;
        }


        ProgressUI.progressUI.setInstructionSpace
        (
            "主人公とデート相手はメリーゴーランドで楽しさを共有し、" + 
            "次に観覧車に乗り、高みからの景色を眺めながら、二人の絆がさらに深まりました。 \r\n" + 
            "キュートな雰囲気とドキドキのシーンが、思い出の中に刻まれました。 \r\n" + 
            friendName + 
            "のあなたに対する好感度が30上がった。"
        );

        Lover thatFriend = player.pi.lovers.getLoverByName(friendName);
        thatFriend.fav.add(50);
        Debug.Log( player.pi.lovers.getLoverByName( friendName ).fav.getValue() );

          yield return base.lde.execute(player);

    }



}
