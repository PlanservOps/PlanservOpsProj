import useTheme from "../../hooks/useTheme";

function ThemeSwitcher() {
  const [theme, setTheme] = useTheme();

  return (
    <button
      className="px-3 py-1 rounded bg-gray-200 dark:bg-gray-700 text-gray-800 dark:text-gray-200 ml-4"
      onClick={() => setTheme(theme === "dark" ? "light" : "dark")}
      title="Alternar tema"
    >
      {theme === "dark" ? "🌞 Claro" : "🌙 Escuro"}
    </button>
  );
}

export default ThemeSwitcher;