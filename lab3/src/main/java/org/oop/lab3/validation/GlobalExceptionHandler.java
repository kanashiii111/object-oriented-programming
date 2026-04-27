package org.oop.lab3.validation;

import java.util.HashMap;
import java.util.Map;

import org.springframework.dao.DataIntegrityViolationException;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.validation.FieldError;
import org.springframework.web.bind.MethodArgumentNotValidException;
import org.springframework.web.bind.annotation.ExceptionHandler;
import org.springframework.web.bind.annotation.ResponseStatus;
import org.springframework.web.bind.annotation.RestControllerAdvice;
import org.springframework.web.context.request.WebRequest;

@RestControllerAdvice
public class GlobalExceptionHandler {
    
    @ExceptionHandler(MethodArgumentNotValidException.class)
    @ResponseStatus(HttpStatus.BAD_REQUEST)
    public Map<String, Object> handleMethodArgumentNotValidException(MethodArgumentNotValidException e, WebRequest request) {
        Map<String, Object> response = new HashMap<>();
        Map<String, String> errors = new HashMap<>();
        
        e.getBindingResult().getAllErrors().forEach(error -> {
            String field = ((FieldError) error).getField();
            String message = ((FieldError) error).getDefaultMessage();
            errors.put(field, message);
        });
        
        response.put("status", HttpStatus.BAD_REQUEST.value());
        response.put("errors", errors);
        response.put("message", "Validation failed");
        
        return response;
    }
    
    @ExceptionHandler(Exception.class)
    @ResponseStatus(HttpStatus.INTERNAL_SERVER_ERROR)
    public Map<String, String> handleGeneralException(Exception e) {
        Map<String, String> response = new HashMap<>();
        response.put("error", "Internal server error");
        response.put("message", e.getMessage());
        return response;
    }

    @ExceptionHandler(DataIntegrityViolationException.class)
    public ResponseEntity<Map<String, Object>> handleDataIntegrityViolationException(DataIntegrityViolationException e) {
        Map<String, Object> response = new HashMap<>();
        Map<String, String> errors = new HashMap<>();
        errors.put("name", "Entry with this name already exists");
        
        String message = "Data integrity failure";
        
        if (e.getMessage() != null && e.getMessage().contains("name")) {
            message = "Entry with this name already exists";
        }

        response.put("status", HttpStatus.CONFLICT.value());
        response.put("message", message);
        response.put("errors", errors); 
        
        return new ResponseEntity<>(response, HttpStatus.CONFLICT);
    }
}