using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakUp
{
    public static IEnumerator execute(Player player)
    {
        ProgressUI.progressUI.setInstructionSpace("...");
        yield return KeyManager.keyManager.waitForSpace();

        if (player.pi.gender == Gender.MAN)
        {
            ProgressUI.progressUI.setInstructionSpace
                (
                player.pi.name +
                "と" +
                player.pi.partner.getName() +
                "は、お気に入りのカフェで座っている。店内は穏やかで、淡い音楽が流れている。"
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setInstructionSpace
                (
                player.pi.name +
                ":今日は何か特別なことでもあるのかな？"
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setInstructionSpace
                (
                player.pi.partner.getName() +
                ":ええ、実は私、大切な話があるの。"
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setInstructionSpace
                (
                player.pi.partner.getName() +
                "は深いため息をつき、ゆっくりと話し始める。"
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setInstructionSpace
                (
                player.pi.partner.getName() +
                ":この関係、私にとってはとても素晴らしいものだったし、いい思い出もできたけど..."
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setInstructionSpace
                (
                player.pi.partner.getName() +
                ":私、もう一歩を踏み出さないといけないと思ったの。"
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setInstructionSpace
                (
                player.pi.name +
                ":一歩を？"
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setInstructionSpace
                (
                player.pi.partner.getName() +
                ":はい。私は自分自身を見つめなおして、これからの人生に向けて進む決断をしなくちゃいけないの。私たちはお互いの成長を妨げてしまうかもしれない。"
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setInstructionSpace
                (
                player.pi.name +
                "は" +
                player.pi.partner.getName() +
                "の言葉を受け入れようとするが、それは難しいものである。"
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setInstructionSpace
                (
                player.pi.name +
                ":でも、なぜ今？"
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setInstructionSpace
                (
                player.pi.partner.getName() +
                ":私たちの未来を考えてみたら、このままだとどちらかが犠牲になるかもしれないと思ったんだ。私たちそれぞれの夢や目標があるでしょう？"
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setInstructionSpace
                (
                player.pi.partner.getName() +
                "は" +
                player.pi.name +
                "の手を取り、優しく微笑む。"
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setInstructionSpace
                (
                player.pi.partner.getName() +
                ":これが私たちの新しい始まりなんだと信じている。私たちは今度は別の道を歩むべきなんだ。"
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setInstructionSpace
                (
                player.pi.name +
                ":君が幸せなら、それが一番だよ。でも、寂しいよ。"
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setInstructionSpace
                (
                player.pi.partner.getName() +
                ":私も寂しいよ。でも、お互いに幸せになるためには、この道を進むしかないんだと思う。"
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setInstructionSpace
                (
                "二人は最後に優しいキスを交わし、それぞれの未来への一歩を踏み出す。カフェの扉が閉まる音が、新しい章の始まりを告げている。"
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setInstructionSpace
                (
                "エピローグ\n~未来への一歩~"
                );

            yield return KeyManager.keyManager.waitForSpace();
        }
        else
        {
            ProgressUI.progressUI.setInstructionSpace
                (
                player.pi.name +
                "と" +
                player.pi.partner.getName() +
                "は、穏やかな午後に落ち着いたカフェで会話しています。雰囲気は和やかで、二人は何かを祝っているかのように微笑んでいます。"
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setInstructionSpace
                (
                "会話が次第に重たくなり、" +
                player.pi.name +
                "と" +
                player.pi.partner.getName() +
                "に視線を向けると、" +
                player.pi.partner.getName() +
                "はためらいながら言葉を続けます。背後から聞こえるカフェの音楽が、二人の間に流れる静寂を際立たせています。"
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setInstructionSpace
                (
                player.pi.partner.getName() +
                "実はね、最近自分の中でいろいろ考えていたんだ。"
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setInstructionSpace
                (
                player.pi.name +
                ":何か悩み事があるの？"
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setInstructionSpace
                (
                player.pi.partner.getName() +
                " うん、正直な話があるんだ。"
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setInstructionSpace
                (
                player.pi.partner.getName() +
                ":君と付き合っていることは素晴らしい時間だったし、いい思い出ができたと思ってるけど、僕自身がこれから進むべき道があって、君との関係がそれに合わない気がしてきたんだ。"
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setInstructionSpace
                (
                player.pi.name +
                "は" +
                player.pi.partner.getName() +
                "の言葉に戸惑いを隠せません。" +
                player.pi.name +
                "の瞳には驚きが宿り、少しずつ理解が追いついていくような表情が浮かびます。"
                );


            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setInstructionSpace
                (
                player.pi.name +
                ": そ、そうなの？"
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setInstructionSpace
                (
                player.pi.partner.getName() +
                ":うん、ごめんなさい。でも、これが君たちの未来にとってベストだと思うんだ。"
                );

            yield return KeyManager.keyManager.waitForSpace();



            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setInstructionSpace
                (
                player.pi.name +
                "はしばらく言葉を失ってしまいます。" +
                player.pi.partner.getName() +
                "は優しく手を差し伸べますが、" +
                player.pi.name +
                "はそれを受け入れることができません。"
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setInstructionSpace
                (
                player.pi.name +
                ":わかったわ。私もありがとう。でも、私たちの時間は素敵だったし、これからも思い出として大切にするから。"
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setInstructionSpace
                (
                "静かなままのカフェで、" +
                player.pi.name +
                "と" +
                player.pi.partner.getName() +
                "は互いに微笑み合いますが、空気には別れの悲しみが漂っています。" +
                player.pi.partner.getName() +
                "は席を立ち、" +
                player.pi.name +
                "に軽く手を振りながらカフェを去っていきます。"
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setInstructionSpace
                (
                "..."
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setInstructionSpace
                (
                player.pi.name +
                "は時間をかけて" +
                player.pi.partner.getName() +
                "との別れを受け入れ、新しい人生へと歩み始めます。やがて、" +
                player.pi.name +
                "は自分自身を取り戻し、新たな可能性に向けて前進していくのでした。"
                );

            yield return KeyManager.keyManager.waitForSpace();
        }
    }
}
