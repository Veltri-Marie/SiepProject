import { useState } from "react"
import { TextField, InputAdornment, IconButton, Box, ThemeProvider, createTheme } from "@mui/material"
import SearchIcon from "@mui/icons-material/Search"
import { alpha } from "@mui/material/styles"

const theme = createTheme({
    palette: {
        primary: {
            main: "#9c27b0",
        },
        secondary: {
            main: "#e91e63",
        },
    },
})

interface ChatBotProps {
    fetchMetier: (name: string) => Promise<void>
}

const ChatBot: React.FC<ChatBotProps> = ({ fetchMetier}) => {
    const [metier, setMetier] = useState("")
    const [isFocused, setIsFocused] = useState(false)

    const handleValidation = async (e: React.FormEvent) => {
        e.preventDefault()
        if (!metier.trim()) return
        await fetchMetier(metier)
    }

    return (
        <ThemeProvider theme={theme}>
            <Box
                sx={{
                    width: "100%",
                    display: "flex",
                    justifyContent: "center",
                    pt: 4,
                }}
            >
                <Box
                    component="form"
                    onSubmit={handleValidation}
                    sx={{
                        width: "100%",
                        maxWidth: "500px",
                        transition: "all 0.3s ease-in-out",
                        transform: isFocused ? "scale(1.05)" : "scale(1)",
                    }}
                >
                    <TextField
                        fullWidth
                        variant="outlined"
                        placeholder="Rechercher un métier..."
                        value={metier}
                        onChange={(e) => setMetier(e.target.value)}
                        onFocus={() => setIsFocused(true)}
                        onBlur={() => setIsFocused(false)}
                        InputProps={{
                            endAdornment: (
                                <InputAdornment position="end">
                                    <IconButton type="submit">
                                        <SearchIcon
                                            sx={{
                                                color: isFocused ? "#e91e63" : "#9c27b0",
                                                transition: "all 0.3s ease-in-out",
                                                transform: isFocused ? "scale(1.1) rotate(15deg)" : "scale(1)",
                                            }}
                                        />
                                    </IconButton>
                                </InputAdornment>
                            ),
                        }}
                        sx={{
                            "& .MuiOutlinedInput-root": {
                                color: "black",
                                fontSize: "1rem",
                                py: 0.5,
                                bgcolor: alpha("#fff", 0.7),
                                borderRadius: 4,
                                transition: "all 0.3s ease-in-out",
                                "& fieldset": {
                                    borderColor: isFocused ? "#e91e63" : "#9c27b0",
                                    borderWidth: 2,
                                    borderRadius: 4,
                                },
                                "&:hover fieldset": {
                                    borderColor: alpha("#e91e63", 0.8),
                                },
                                "&.Mui-focused fieldset": {
                                    borderColor: "#e91e63",
                                },
                            },
                            "& .MuiInputBase-input::placeholder": {
                                color: alpha("#21234e", 0.6),
                                opacity: 1,
                            },
                        }}
                    />
                </Box>
            </Box>
        </ThemeProvider>
    )
}

export default ChatBot
