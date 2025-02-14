import { styled } from "@mui/system";
import { Paper, TextField, Typography } from "@mui/material";

export const StyledPaper = styled(Paper)(({ theme }) => ({
    flex: 1,
    padding: theme.spacing(3),
    borderRadius: "8px",
    backgroundColor: "#fff",
    minWidth: "300px",
    maxWidth: "400px",
    height: "fit-content",
    alignSelf: "flex-start",
}));

export const StyledTypography = styled(Typography)(({ theme }) => ({
    marginBottom: theme.spacing(2),
    fontWeight: "bold",
}));

export const StyledTextField = styled(TextField)(({ theme }) => ({
    margin: theme.spacing(1, 0),
}));

