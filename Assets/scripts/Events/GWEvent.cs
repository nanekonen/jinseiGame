﻿using System.Collections;
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

        //ProgressUI.progressUI.setLove("");

        ProgressUI.progressUI.changeTurn(player);

        ProgressUI.progressUI.setInstructionSpace( player.pi.name + "さんの強制イベントです！！");
        yield return KeyManager.keyManager.waitForSpace();

        ProgressUI.progressUI.setInstructionSpace
        (
            "ゴールデンウィーク到来！遊園地に遊びに行きます。\n" +
            "思い切り楽しんで、素敵な時間を過ごしましょう！ ");
        yield return KeyManager.keyManager.waitForSpace();

        ProgressUI.progressUI.setInstructionSpace(
            "心から楽しい時間を過ごすために、\nどちらの" 
            + ( (player.pi.gender == Gender.MAN)? "女" : "男" )  
            + "性と過ごすか選択してください。 "
        );

        yield return KeyManager.keyManager.waitForSpace();

        List<string> friendNames = player.pi.lovers.getAllLoverName();
        string friendName = "";


        ProgressUI.progressUI.setInstructionSpace
        (
            friendNames[1] + ":左矢印" + friendNames[0] + ":右矢印 "
        );
        
        IEnumerator waitForRightOrLeftArrow = KeyManager.keyManager.waitForRightOrLeftArrow();
        yield return waitForRightOrLeftArrow;
        string leftOrRight = (string)waitForRightOrLeftArrow.Current;
        Debug.Log(leftOrRight);
        if (leftOrRight == "right")
        {
            friendName = friendNames[0];
        }
        else
        {
            friendName = friendNames[1];
        }
        ProgressUI.progressUI.setLove(background[6], player.pi.lovers.getLoverByName(friendName).getPrivate(), "",friendName);
        if( player.pi.gender == Gender.WOMAN )
        {
            ProgressUI.progressUI.setLove_sentence
            (
                friendName + 
                ":「今日は楽しかったね。遊園地めっちゃ盛り上がった！」 "
            );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setLove_sentence
            (
                friendName + 
                ":「今日は楽しかったね。遊園地めっちゃ盛り上がった！」\r\n" + "" +
                "あなた:「うん、最高だった。\nジェットコースターも観覧車もすごかったね。」 "
            );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setLove_sentence
            (
                friendName + 
                ":「今日は楽しかったね。遊園地めっちゃ盛り上がった！」 \r\n" + "" +
                "あなた「うん、最高だった。\nジェットコースターも観覧車もすごかったね。」 \n" + 
                friendName + 
                ":「君と一緒にいると、どんな場所も楽しいな。」"
            );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setLove_sentence
            (
                "A．「そうだね、私もすごく楽しかった。ありがとう。」 \r\n" + "" +
                "B．「また行きたくなっちゃったね！\n一緒に行ける日を楽しみにしてるね」"
            );

            IEnumerator waitForAOrB = KeyManager.keyManager.waitForAOrB();
            yield return waitForAOrB;
            string AorB = (string)waitForAOrB.Current;
        }
        else if( player.pi.gender == Gender.MAN )
        {
            ProgressUI.progressUI.setLove_sentence
            (
                "あなた:「今日は楽しかったね。遊園地めっちゃ盛り上がった！」"
            );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setLove_sentence
            (
                friendName + 
                ":「うん、最高だった。\nジェットコースターも観覧車もすごかったね。」"
            );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setLove_sentence
            (
                "A．「君と一緒にいると、どんな場所も楽しいな。」 \r\n" + "" +
                "B．「また行こうぜ！次はもっと楽しい時間を過ごそう！」"
            );

            IEnumerator waitForAOrB = KeyManager.keyManager.waitForAOrB();
            yield return waitForAOrB;
            string AorB = (string)waitForAOrB.Current;
        }


        ProgressUI.progressUI.setLove_sentence
        (
            "主人公とデート相手はメリーゴーランドで楽しさを共有し、" +
            "次に観覧車に乗り、高みからの景色を眺めながら、\n" +
            "二人の絆がさらに深まりました。 ");

        yield return KeyManager.keyManager.waitForSpace();

        ProgressUI.progressUI.setLove_sentence(
            "キュートな雰囲気とドキドキのシーンが、" +
            "\n思い出の中に刻まれました。 \n\n" + 
            friendName + 
            "のあなたに対する好感度が50上がった。"
        );

        Lover thatFriend = player.pi.lovers.getLoverByName(friendName);
        thatFriend.fav.add(50);
        Debug.Log( player.pi.lovers.getLoverByName( friendName ).fav.getValue() );
          yield return base.lde.execute(player);

    }



}
