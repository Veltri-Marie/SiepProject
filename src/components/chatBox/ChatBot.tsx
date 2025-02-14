import { InputAdornment, IconButton } from "@mui/material";
import SearchIcon from "@mui/icons-material/Search";
import { StyledContainer, StyledForm, StyledTextField, StyledSearchIcon } from "./ChatBot.styles";
import useSearch from "../../hooks/useSearch"; // Import du hook personnalisé

interface ChatBotProps {
    fetchMetier: (name: string) => Promise<void>;
}

const ChatBot: React.FC<ChatBotProps> = ({ fetchMetier }) => {
    const { value, isFocused, handleSubmit, handleChange, handleFocus, handleBlur } = useSearch();

    return (
        <StyledContainer>
            <StyledForm component="form" onSubmit={(e) => handleSubmit(e, fetchMetier)} isFocused={isFocused}>
                <StyledTextField
                    fullWidth
                    variant="outlined"
                    placeholder="Rechercher un métier..."
                    value={value}
                    onChange={handleChange}
                    onFocus={handleFocus}
                    onBlur={handleBlur}
                    isFocused={isFocused}
                    InputProps={{
                        endAdornment: (
                            <InputAdornment position="end">
                                <IconButton type="submit">
                                    <StyledSearchIcon
                                        as={SearchIcon}
                                        isFocused={isFocused}
                                    />
                                </IconButton>
                            </InputAdornment>
                        ),
                    }}
                />
            </StyledForm>
        </StyledContainer>
    );
};

export default ChatBot;
