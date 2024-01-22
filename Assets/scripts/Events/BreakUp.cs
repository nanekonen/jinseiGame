using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakUp
{
    public static IEnumerator execute(Player player)
    {
        ProgressUI.progressUI.setLove(ForcedEvent.background[5], player.pi.lovers.getLoverByName(player.pi.partner.getName()).getPrivate(), "", "");
        string playerName = player.name;
        string partnerName = player.pi.partner.getName();
        ProgressUI.progressUI.setLove_sentence("...");
        yield return KeyManager.keyManager.waitForSpace();

        if (player.pi.gender == Gender.MAN)
        {
            ProgressUI.progressUI.setLove_sentence_name
                (
                playerName +
                "と" +
                partnerName +
                "は、お気に入りのカフェで座っている。店内は穏やかで、淡い音楽が流れている。"
                ,"ナレーション"
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setLove_sentence_name
                (
                "今日は何か特別なことでもあるのかな？",
                playerName
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setLove_sentence_name
                (
                "ええ、実は私、大切な話があるの。",
                partnerName
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setLove_sentence_name
                (
                partnerName +
                "は深いため息をつき、ゆっくりと話し始める。",
                "ナレーション"
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setLove_sentence_name
                (
                "この関係、私にとってはとても素晴らしいものだったし、いい思い出もできたけど...",
                partnerName
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setLove_sentence_name
                (
                "私、もう一歩を踏み出さないといけないと思ったの。",
                partnerName
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setLove_sentence_name
                (
                "一歩を？",
                playerName
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setLove_sentence_name
                (
                "はい。私は自分自身を見つめなおして、これからの人生に向けて進む決断をしなくちゃいけないの。私たちはお互いの成長を妨げてしまうかもしれない。",
                partnerName
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setLove_sentence_name
                (
                playerName +
                "は" +
                partnerName +
                "の言葉を受け入れようとするが、それは難しいものである。",
                "ナレーション"
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setLove_sentence_name
                (
                "でも、なぜ今？",
                playerName
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setLove_sentence_name
                (
                "私たちの未来を考えてみたら、このままだとどちらかが犠牲になるかもしれないと思ったんだ。私たちそれぞれの夢や目標があるでしょう？",
                partnerName
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setLove_sentence_name
                (
                partnerName +
                "は" +
                playerName +
                "の手を取り、優しく微笑む。",
                "ナレーション"
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setLove_sentence_name
                (
                "これが私たちの新しい始まりなんだと信じている。私たちは今度は別の道を歩むべきなんだ。",
                partnerName
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setLove_sentence_name
                (
                "君が幸せなら、それが一番だよ。でも、寂しいよ。",
                playerName
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setLove_sentence_name
                (
                "私も寂しいよ。でも、お互いに幸せになるためには、この道を進むしかないんだと思う。",
                partnerName
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setLove_sentence_name
                (
                "二人は最後に優しいキスを交わし、それぞれの未来への一歩を踏み出す。カフェの扉が閉まる音が、新しい章の始まりを告げている。",
                "ナレーション"
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setLove_sentence
                (
                "エピローグ\n~未来への一歩~"
                );

            yield return KeyManager.keyManager.waitForSpace();
        }
        else
        {
            ProgressUI.progressUI.setLove_sentence_name
                (
                playerName +
                "と" +
                partnerName +
                "は、穏やかな午後に落ち着いたカフェで会話しています。雰囲気は和やかで、二人は何かを祝っているかのように微笑んでいます。",
                "ナレーション"
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setLove_sentence
                (
                "会話が次第に重たくなり、" +
                playerName +
                "と" +
                partnerName +
                "に視線を向けると、" +
                partnerName +
                "はためらいながら言葉を続けます。背後から聞こえるカフェの音楽が、二人の間に流れる静寂を際立たせています。"
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setLove_sentence_name
                (
                "実はね、最近自分の中でいろいろ考えていたんだ。",
                partnerName
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setLove_sentence_name
                (
                "何か悩み事があるの？",
                playerName
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setLove_sentence_name
                (
                "うん、正直な話があるんだ。",
                partnerName
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setLove_sentence
                (
                "君と付き合っていることは素晴らしい時間だったし、いい思い出ができたと思ってるけど、僕自身がこれから進むべき道があって、君との関係がそれに合わない気がしてきたんだ。"
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setLove_sentence_name
                (
                playerName +
                "は" +
                partnerName +
                "の言葉に戸惑いを隠せません。" +
                playerName +
                "の瞳には驚きが宿り、少しずつ理解が追いついていくような表情が浮かびます。",
                "ナレーション"
                );


            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setLove_sentence_name
                (
                "そ、そうなの？",
                playerName
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setLove_sentence_name
                (
                "うん、ごめんなさい。でも、これが君たちの未来にとってベストだと思うんだ。",
                partnerName
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setLove_sentence_name
                (
                playerName +
                "はしばらく言葉を失ってしまいます。" +
                partnerName +
                "は優しく手を差し伸べますが、" +
                playerName +
                "はそれを受け入れることができません。",
                "ナレーション"
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setLove_sentence_name
                (
                "わかったわ。私もありがとう。でも、私たちの時間は素敵だったし、これからも思い出として大切にするから。",
                playerName
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setLove_sentence_name
                (
                "静かなままのカフェで、" +
                playerName +
                "と" +
                partnerName +
                "は互いに微笑み合いますが、空気には別れの悲しみが漂っています。" +
                partnerName +
                "は席を立ち、" +
                playerName +
                "に軽く手を振りながらカフェを去っていきます。",
                "ナレーション"
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setLove_sentence
                (
                "..."
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setLove_sentence
                (
                playerName +
                "は時間をかけて" +
                partnerName +
                "との別れを受け入れ、新しい人生へと歩み始めます。やがて、" +
                playerName +
                "は自分自身を取り戻し、新たな可能性に向けて前進していくのでした。"
                );

            yield return KeyManager.keyManager.waitForSpace();
        }
        ProgressUI.progressUI.beingSugoroku();
        yield break;
    }
}
