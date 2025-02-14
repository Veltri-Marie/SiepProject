import { styled } from "@mui/system";
import { Box, Typography } from "@mui/material";

export const StyledContainer = styled(Box)({
    width: "100%",
    display: "flex",
    flexDirection: "column",
    gap: "24px",
    marginTop: "16px",
});

export const StyledBox = styled(Box)({
    width: "100%",
    maxWidth: "1200px",
    height: "400px",
    backgroundColor: "#fff",
    border: "1px solid #ccc",
    borderRadius: "8px",
    padding: "16px",
    boxShadow: "0px 4px 8px rgba(0, 0, 0, 0.1)",
    alignSelf: "center",
    display: "flex",
    flexDirection: "column",
    overflow: "hidden",
});

export const StyledTypography = styled(Typography)({
    marginBottom: "8px",
});

export const StyledEditorContainer = styled("div")({
    flex: 1,
    maxHeight: "300px",
    overflow: "auto",
});
