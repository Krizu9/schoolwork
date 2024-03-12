defmodule Color do
  def askUser(colors) do
    user_input = String.trim(IO.gets("Color or html value (type 'exit' to quit): "))
    case user_input do
      "exit" -> :ok
      _ ->
        case processInput(colors, user_input) do
          {:html_color, hex} ->
            IO.puts("Html color value: #{hex}")
            askUser(colors)
          {:color_name, color_name} ->
            IO.puts("Color name: #{color_name}")
            askUser(colors)
          :not_found ->
            IO.puts("Color not found")
            askUser(colors)
        end
    end
  end

  defp processInput(colors, user_input) do
    case Keyword.get(colors, String.to_atom(user_input)) do
      hex when is_binary(hex) ->
        {:html_color, hex}
      nil ->
        case Enum.find(colors, fn {color, hex} -> String.equivalent?(hex, user_input) end) do
          {color, _} when is_atom(color) ->
            {:color_name, color}
          _ ->
            :not_found
        end
    end
  end
end

colors = [
  AliceBlue: "#F0F8FF",
  AntiqueWhite: "#FAEBD7",
  Aqua: "#00FFFF",
  Aquamarine: "#7FFFD4",
  Acure: "#F0FFFF",
  Beige: "#F5F5DC",
  Bisque: "#FFE4C4",
  Black: "#000000",
  BlanchedAlmond: "#FFEBCD"
]

Color.askUser(colors)
