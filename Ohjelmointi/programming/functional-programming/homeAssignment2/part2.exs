defmodule PigLatin do
  @consonant_groups ~w(ch qu squ th thr sch)
  @vowel_groups ~w(yt xr)

  def translate_word(word) when is_binary(word) and byte_size(word) > 0 do
    case String.split_at(word, 1) do
      {match, rest} when match in @vowel_groups -> "#{word}ay"
      {match, rest} when match in @consonant_groups -> "#{rest}#{match}ay"
      {_, _} -> "#{word}ay"
    end
  end

  def translate_phrase(phrase) when is_binary(phrase) and byte_size(phrase) > 0 do
    phrase
    |> String.split(~r/\s+/)
    |> Enum.map(&translate_word/1)
    |> Enum.join(" ")
  end
end

phrase = "Pattern Matching with Elixir. Remember that equals sign is a match operator, not an assignment."
translated_phrase = PigLatin.translate_phrase(phrase)
IO.puts(translated_phrase)
