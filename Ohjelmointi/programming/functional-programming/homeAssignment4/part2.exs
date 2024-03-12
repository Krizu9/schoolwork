defmodule BookManager do
  def main do
    books = %{
      "111-222-33333-4-4" => "Clean Code",
      "222-333-44444-5-6" => "Programming Elixir",
      "333-444-55555-6-7" => "Design Patterns: Elements of Reusable Object-Oriented Software",
      "444-555-66666-7-8" => "The Pragmatic Programmer",
      "555-666-77777-8-9" => "Elixir in Action"
    }
    loop(books)
  end

  def loop(books) do
    user_input = String.trim(IO.gets("Enter a command (list, search ISBN, add ISBN,NAME, remove ISBN, quit): "))

    case String.split(user_input, " ") do
      ["list"] ->
        IO.puts("List of books:")
        Enum.each(books, fn {isbn, name} -> IO.puts("#{isbn}: #{name}") end)
        loop(books)

      ["search", isbn] ->
        case Map.get(books, isbn) do
          nil ->
            IO.puts("Book with ISBN #{isbn} not found.")
          name ->
            IO.puts("Book found:")
            IO.puts("#{isbn}: #{name}")
        end
        loop(books)

      ["add", isbn, name] ->
        case Map.get(books, isbn) do
          nil ->
            updated_books = Map.put(books, isbn, name)
            IO.puts("Book added successfully.")
            loop(updated_books)
          _ ->
            IO.puts("Book with ISBN #{isbn} already exists.")
            loop(books)
        end

      ["remove", isbn] ->
        case Map.get(books, isbn) do
          nil ->
            IO.puts("Book with ISBN #{isbn} not found.")
          _ ->
            updated_books = Map.delete(books, isbn)
            IO.puts("Book removed successfully.")
            loop(updated_books)
        end

      ["quit"] ->
        IO.puts("Goodbye!")
        :ok

      _ ->
        IO.puts("Invalid command. Please try again.")
        loop(books)
    end
  end
end

BookManager.main()
