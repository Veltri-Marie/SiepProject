import { styled } from "@mui/system";
import { Box, TextField } from "@mui/material";
import { alpha } from "@mui/material/styles";

export const StyledContainer = styled(Box)({
    width: "100%",
    display: "flex",
    justifyContent: "center",
    paddingTop: "32px",
});

export const StyledForm = styled(Box)<{ isFocused: boolean, component?: React.ElementType }>(({ isFocused }) => ({
    width: "100%",
    maxWidth: "500px",
    transition: "all 0.3s ease-in-out",
    transform: isFocused ? "scale(1.05)" : "scale(1)",
}));

export const StyledTextField = styled(TextField)<{ isFocused: boolean }>(({ isFocused }) => ({
    "& .MuiOutlinedInput-root": {
        color: "black",
        fontSize: "1rem",
        padding: "4px 0",
        backgroundColor: alpha("#fff", 0.7),
        borderRadius: "16px",
        transition: "all 0.3s ease-in-out",
        "& fieldset": {
            borderColor: isFocused ? "#e91e63" : "#9c27b0",
            borderWidth: 2,
            borderRadius: "16px",
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
}));

export const StyledSearchIcon = styled("svg")<{ isFocused: boolean }>(({ isFocused }) => ({
    color: isFocused ? "#e91e63" : "#9c27b0",
    transition: "all 0.3s ease-in-out",
    transform: isFocused ? "scale(1.1) rotate(15deg)" : "scale(1)",
}));
