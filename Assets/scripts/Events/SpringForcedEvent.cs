using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpringForcedEvent : ForcedEvent 
{


    public SpringForcedEvent
    (
        string text,
        int timing,
        int favorability1,
        int favorability2
    )
    : base()
    {
        base.text = text;
        base.timing = timing;
        base.favorability1 = favorability1;
        base.favorability2 = favorability2;
    }

    public override IEnumerator execute(Season season, Round round, Player player)
    {
         Debug.Log("this is from spring force event");

        if (season.getID() != Season.SPRING) yield break;
        if (round.getRound() != base.timing) yield break;

          ProgressUI.progressUI.setInstructionSpace(base.text);

        yield return KeyManager.keyManager.waitForSpace();

        ProgressUI.progressUI.setInstructionSpace
        (
            "ゴールデンウィーク到来！遊園地に遊びに行きます。思い切り楽しんで、素敵な時間を過ごしましょう！ 心から楽しい時間を過ごすために、どちらの男性と過ごすか選択してください。 "
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
                friendName + ":「今日は楽しかったね。遊園地めっちゃ盛り上がった！」 "
            );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setInstructionSpace
            (
                friendName + ":「今日は楽しかったね。遊園地めっちゃ盛り上がった！」\r\nあなた:「うん、最高だった。ジェットコースターも観覧車もすごかったね。」 "
            );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setInstructionSpace
            (
                friendName + ":「今日は楽しかったね。遊園地めっちゃ盛り上がった！」 \r\nあなた「うん、最高だった。ジェットコースターも観覧車もすごかったね。」 \r\n" + friendName + ":「君と一緒にいると、どんな場所も楽しいな。」"
            );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setInstructionSpace
            (
                "A．「そうだね、私もすごく楽しかった。ありがとう。」 \r\nB．「また行きたくなっちゃったね！一緒に行ける日を楽しみにしてるね」"
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
                friendName + ":「うん、最高だった。ジェットコースターも観覧車もすごかったね。」"
            );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setInstructionSpace
            (
                "A．「君と一緒にいると、どんな場所も楽しいな。」 \r\nB．「また行こうぜ！次はもっと楽しい時間を過ごそう！」"
            );

            IEnumerator waitForAOrB = KeyManager.keyManager.waitForAOrB();
            yield return waitForAOrB;
            string AorB = (string)waitForAOrB.Current;
        }


        ProgressUI.progressUI.setInstructionSpace
        (
            "主人公とデート相手はメリーゴーランドで楽しさを共有し、次に観覧車に乗り、高みからの景色を眺めながら、二人の絆がさらに深まりました。 \r\nキュートな雰囲気とドキドキのシーンが、思い出の中に刻まれました。 \r\n" + friendName + "のあなたに対する好感度が〇上がった。"
        );

        player.pi.lovers.getLoverByName(friendName).fav.add(30);
        Debug.Log( player.pi.lovers.getLoverByName( friendName ).fav.getValue() );


    }



}
